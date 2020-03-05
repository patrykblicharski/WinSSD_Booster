using System;
using System.ServiceProcess;

namespace WinSSD_Booster.Controler
{
    public class ServicesControler
    {
        public void strop(string serviceName)
        {
            //            var svc = new ServiceController("wsearch");
            //            EnterpriseServicesHelper.ch
        }
        public bool StartService(string serviceName, int timeOutMills)
        {
            var timeOut = TimeSpan.FromMilliseconds(timeOutMills);

            try
            {
                var controller = new ServiceController(serviceName);
                if (controller.Status != ServiceControllerStatus.Running)
                {
                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running, timeOut);
                    //                    while (controller.Status == ServiceControllerStatus.Paused)
                    //                    {
                    //                        Thread.Sleep(1000);
                    //                        controller.Refresh();
                    //                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool StopService(string serviceName, int timeOutMills)
        {
            var timeOut = TimeSpan.FromMilliseconds(timeOutMills);

            try
            {
                var controller = new ServiceController(serviceName);
                if (controller.Status != ServiceControllerStatus.Stopped)
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, timeOut);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RestartService(string serviceName, int timeOutMills)
        {
            var timeOut = TimeSpan.FromMilliseconds(timeOutMills);
            int millisec1 = Environment.TickCount;
            try
            {
                var controller = new ServiceController(serviceName);
                if (controller.Status != ServiceControllerStatus.Running)
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, timeOut);
                    int millisec2 = Environment.TickCount;
                    timeOut = TimeSpan.FromMilliseconds(timeOutMills - (millisec2 - millisec1));

                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running, timeOut);

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ServiceControllerStatus Getaaa(string serviceName)
        {
            try
            {
                var controller = new ServiceController(serviceName);
                return controller.Status;
            }
            catch
            {
                return 0;
            }
        }

        public ServiceControllerStatus Getaaa(ServiceController controller)
        {
            return controller.Status;
        }
    }
}