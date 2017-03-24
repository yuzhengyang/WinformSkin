using Client.UI.Base.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Client.UI.Base.Utils
{
    public sealed class HandleCollector
    {
        // Events
        internal static event HandleChangeEventHandler HandleAdded;
        internal static event HandleChangeEventHandler HandleRemoved;

        // Methods
        static HandleCollector()
        {
            HandleCollector.internalSyncObject = new object();
        }

        public HandleCollector()
        {
        }

        public static IntPtr Add(IntPtr handle, int type)
        {
            HandleCollector.handleTypes[type - 1].Add(handle);
            return handle;
        }

        public static int RegisterType(string typeName, int expense, int initialThreshold)
        {
            int num1;
            lock (HandleCollector.internalSyncObject)
            {
                if ((HandleCollector.handleTypeCount == 0) || (HandleCollector.handleTypeCount == HandleCollector.handleTypes.Length))
                {
                    HandleCollector.HandleType[] typeArray1 = new HandleCollector.HandleType[HandleCollector.handleTypeCount + 10];
                    if (HandleCollector.handleTypes != null)
                    {
                        Array.Copy(HandleCollector.handleTypes, 0, typeArray1, 0, HandleCollector.handleTypeCount);
                    }
                    HandleCollector.handleTypes = typeArray1;
                }
                HandleCollector.handleTypes[HandleCollector.handleTypeCount++] = new HandleCollector.HandleType(typeName, expense, initialThreshold);
                num1 = HandleCollector.handleTypeCount;
            }
            return num1;
        }

        public static IntPtr Remove(IntPtr handle, int type)
        {
            return HandleCollector.handleTypes[type - 1].Remove(handle);
        }

        public static void ResumeCollect()
        {
            bool flag1 = false;
            lock (HandleCollector.internalSyncObject)
            {
                if (HandleCollector.suspendCount > 0)
                {
                    HandleCollector.suspendCount--;
                }
                if (HandleCollector.suspendCount == 0)
                {
                    for (int num1 = 0; num1 < HandleCollector.handleTypeCount; num1++)
                    {
                        lock (HandleCollector.handleTypes[num1])
                        {
                            if (HandleCollector.handleTypes[num1].NeedCollection())
                            {
                                flag1 = true;
                            }
                        }
                    }
                }
            }
            if (flag1)
            {
                GC.Collect();
            }
        }

        public static void SuspendCollect()
        {
            lock (HandleCollector.internalSyncObject)
            {
                HandleCollector.suspendCount++;
            }
        }


        // Fields
        private static int handleTypeCount;
        private static HandleCollector.HandleType[] handleTypes;
        private static object internalSyncObject;
        private static int suspendCount;

        // Nested Types
        private class HandleType
        {
            // Methods
            internal HandleType(string name, int expense, int initialThreshHold)
            {
                this.name = name;
                this.initialThreshHold = initialThreshHold;
                this.threshHold = initialThreshHold;
                this.deltaPercent = 100 - expense;
            }

            internal void Add(IntPtr handle)
            {
                if (handle != IntPtr.Zero)
                {
                    bool flag1 = false;
                    int num1 = 0;
                    lock (this)
                    {
                        this.handleCount++;
                        flag1 = this.NeedCollection();
                        num1 = this.handleCount;
                    }
                    lock (HandleCollector.internalSyncObject)
                    {
                        if (HandleCollector.HandleAdded != null)
                        {
                            HandleCollector.HandleAdded(this.name, handle, num1);
                        }
                    }
                    if (flag1 && flag1)
                    {
                        GC.Collect();
                        int num2 = (100 - this.deltaPercent) / 4;
                        Thread.Sleep(num2);
                    }
                }
            }

            internal int GetHandleCount()
            {
                int num1;
                lock (this)
                {
                    num1 = this.handleCount;
                }
                return num1;
            }

            internal bool NeedCollection()
            {
                if (HandleCollector.suspendCount <= 0)
                {
                    if (this.handleCount > this.threshHold)
                    {
                        this.threshHold = this.handleCount + ((this.handleCount * this.deltaPercent) / 100);
                        return true;
                    }
                    int num1 = (100 * this.threshHold) / (100 + this.deltaPercent);
                    if ((num1 >= this.initialThreshHold) && (this.handleCount < ((int)(num1 * 0.9f))))
                    {
                        this.threshHold = num1;
                    }
                }
                return false;
            }

            internal IntPtr Remove(IntPtr handle)
            {
                if (handle != IntPtr.Zero)
                {
                    int num1 = 0;
                    lock (this)
                    {
                        this.handleCount--;
                        if (this.handleCount < 0)
                        {
                            this.handleCount = 0;
                        }
                        num1 = this.handleCount;
                    }
                    lock (HandleCollector.internalSyncObject)
                    {
                        if (HandleCollector.HandleRemoved != null)
                        {
                            HandleCollector.HandleRemoved(this.name, handle, num1);
                        }
                    }
                }
                return handle;
            }


            // Fields
            private readonly int deltaPercent;
            private int handleCount;
            private int initialThreshHold;
            internal readonly string name;
            private int threshHold;
        }
    }
}
