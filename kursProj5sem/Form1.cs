using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace kursProj5sem
{
    public partial class Form1 : Form
    {
        UInt64 mbs = 1048576;
        UInt64 gbs = 1073741824;
        
        public Form1()
        {
            InitializeComponent();
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            ObjectQuery queryBattery = new ObjectQuery("Select * FROM Win32_Battery");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(queryBattery);
            ManagementObjectCollection collection = searcher.Get();
            if (collection.Count!=0)
            {
                foreach (ManagementObject item in collection)
                {
                    if (collection.Count != 0)
                    {
                        labelBattery.Text = $"{ item["EstimatedChargeRemaining"]} %";
                    }
                    else
                    {
                        labelBattery.Text = "Вы зашли с компьютера, у вас нет батареи";
                    }


                }
            }
            else
            {
                labelBattery.Text = "Вы сидите с компьютера,у вас нет батареи";
            }
            
            ManagementObjectSearcher searcherRAM = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject item in searcherRAM.Get())
            {
                labelRam.Text=$"Всего оперативной памяти: {item["TotalVisibleMemorySize"]} KB";
                    
                labelRam2.Text= $"Свободно оперативной памяти: {item["FreePhysicalMemory"]} KB";
            }
            ManagementObjectSearcher searcherMEM = new ManagementObjectSearcher("select FreeSpace,Size,Name,SystemName from Win32_LogicalDisk");
            foreach (ManagementObject item in searcherMEM.Get())
            {
                label3.Text=$"Название компьютера: {item["SystemName"]}";
                UInt64 allSpace = (UInt64)item["Size"];
                UInt64 freeSpace = (UInt64)item["FreeSpace"];
                UInt64 spaceInMBs = allSpace / mbs;
                UInt64 spaceInGBs = allSpace / gbs;
                UInt64 freeInMBs = freeSpace / mbs;
                UInt64 freeInGBs = freeSpace / gbs;
                label1.Text=$"Изначальное количество места на дисках {spaceInMBs} МБ ({spaceInGBs} ГБ)";
                label5.Text=$"Свободно дискового пространства {freeInMBs} МБ ({freeInGBs} ГБ)";
            }
            int u = 0;
            string gpuText = "";
            ManagementObjectSearcher searcherGPU = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject item in searcherGPU.Get())
            {
                
                    gpuText+=$"Название {item["Caption"]}\n";



                    foreach (PropertyData data in item.Properties)
                    {

                        switch (data.Name)
                        {
                            case "AdapterRAM":
                                gpuText+=$"количество памяти {data.Value} Б \n";
                                break;
                            default:
                                break;
                        }

                    }
                    
                
            }
            
            label6.Text=gpuText; 
        }

        private void labelBattery_Click(object sender, EventArgs e)
        {

        }

        private void labelRam_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CPUInfo.Cores.Clear();
            var CoreTask = Task.Factory
                .StartNew(() =>
                {
                    ManagementObjectSearcher searcherProcUsage = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
                    foreach (ManagementObject obj in searcherProcUsage.Get())
                    {
                        if (obj["Name"] == "_Total")
                        {
                            CPUInfo.TotalUsage = Convert.ToInt32(obj["PercentProcessorTime"]);
                        }
                        else
                        {
                            Core core = new Core();
                            core.CPUCoreName = obj["Name"].ToString();
                            core.CPUCoreUsage = Convert.ToInt32(obj["PercentProcessorTime"]);
                            CPUInfo.Cores.Add(core);
                        }

                        //CPUInfo.CPUCoreNames.Add(obj["Name"].ToString());
                        //CPUInfo.CPUCoresUsage.Add(Convert.ToInt32(obj["PercentProcessorTime"]));




                    }

                    FormCPU formCPU = new FormCPU();
                    formCPU.ShowDialog();
                });
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInfo();
            foreach (var item in this.Controls)
            {
                if (item is Label)
                {
                    Label label = (Label)item;
                    label.Update();
                }
                
            }
            CPUInfo.Cores.Clear();
        }

        private void buttonRam_Click(object sender, EventArgs e)
        {
            FormRAM formRAM = new FormRAM();
            formRAM.ShowDialog();
        }
    }
}
