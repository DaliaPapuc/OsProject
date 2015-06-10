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


namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Text = "Remote Assistance";
            label10.Text = "Remote Desktop";
            checkBox1.Text = "Allow Remote Assistance connection to this computer";
            label29.Text = "Choose an option, and then specify who can connect.";
            radioButton1.Text = "Don't allow remote connections to this computer";
            radioButton2.Text = "Allow remote connections to this computer";
            checkBox2.Text = "Allow connections only from computers running Remote Desktop with Network Level Authentication (recommended)";
            linkLabel1.Text = "What happens when I enable Remote Assistance ?";
            linkLabel2.Text = "Help me choose";
            button1.Text = "Advanced...";
            button2.Text = "Select Users";

            ManagementObjectSearcher Processor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject processorData in Processor.Get())
            {
                if (processorData["name"] != null)
                    label20.Text = processorData["name"].ToString();

                /*               if (processorData["Architecture"] != null) {
                                    switch(processorData["Architecture"].ToString())
                                    {
                                        case "0": label18.Text = "x86-based processor, "; break;
                                        case "1": label18.Text = "MIPS-based processor, "; break;
                                        case "2": label18.Text = "Alpha-based processor, "; break;
                                        case "3": label18.Text = "PowerPC-based processor, "; break;
                                        case "5": label18.Text = "ARM-based processor, "; break;
                                        case "6": label18.Text = "Itanium-basedSystems-based processor, "; break;
                                        case "9": label18.Text = "x64-based processor, "; break;  
                                    }
                    
                                }
                */
            }

            label19.Text = (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024 * 1024)).ToString() + "MB";
            ManagementObjectSearcher os = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject osData in os.Get())
            {
                if (osData["OSArchitecture"] != null)
                    label18.Text = osData["OSArchitecture"].ToString() + " Operating System, ";
                if (osData["Caption"] != null)
                    label5.Text = osData["Caption"].ToString();
                if (osData["Manufacturer"] != null)
                    label6.Text = osData["Manufacturer"].ToString() + ". All rights reserved.";
                // if (osData["name"] != null)
                label27.Text = System.Environment.MachineName;
                if (osData["RegisteredUser"] != null)
                    label28.Text = osData["RegisteredUser"].ToString();
                if (osData["Description"] != null)
                    label26.Text = osData["Description"].ToString();
                if (osData["SerialNumber"] != null)
                    label12.Text = osData["SerialNumber"].ToString();

            }
            ManagementObjectSearcher cs = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject csData in cs.Get())
            {
                if (csData["Workgroup"] != null)
                    label25.Text = csData["Workgroup"].ToString();
                if (csData["SystemType"] != null)
                    label18.Text = label18.Text + csData["SystemType"].ToString();


            }
            /* ManagementObject sac = new ManagementObject("SELECT LicenseStatus FROM SoftwareLicensingService");
             //ManagementObject sacData = sac.Get();
             {
                 PropertyData sacData=sac.Properties.ToString()
                 label11.Text = sac.Properties.
             }
             foreach (ManagementObject sacData in sac.Get())
                         {
                             switch ((UInt32)sacData["LicenseStatus"]) {
                                 case 0: label11.Text = "Unlicensed"; 
                                     break;
                                 case 1: label11.Text = "Licensed"; 
                                     break;
                                 case 2: label11.Text = "OutOfBoxGrace"; 
                                     break;
                                 case 3: label11.Text = "OutOfToleranceGrace"; break;
                                 case 4: label11.Text = "NonGenuineGrace"; break;
                                 case 5: label11.Text = "Notificatian"; break;
                             }
                
                         }*/



            TreeNode item1 = new TreeNode("Audio");
            TreeNode item2 = new TreeNode("Computer");
            TreeNode item3 = new TreeNode("Disk drives");
            TreeNode item4 = new TreeNode("Display Adapters");
            TreeNode item5 = new TreeNode("DVD/CD-ROM drives");
            TreeNode item6 = new TreeNode("Human Interface Devices");
            TreeNode item7 = new TreeNode("IDE ATA/ATAPI controllers");
            TreeNode item8 = new TreeNode("Keyboards");
            TreeNode item9 = new TreeNode("Mice and other pointing devices");
            TreeNode item10 = new TreeNode("Monitors");
            TreeNode item11 = new TreeNode("Network Adapters");
            TreeNode item12 = new TreeNode("Print Queues");
            TreeNode item13 = new TreeNode("Processors");
            TreeNode item14 = new TreeNode("Sensors");
            TreeNode item15 = new TreeNode("Software devices");
            TreeNode item16 = new TreeNode("Sound, video and game controllers");
            TreeNode item17 = new TreeNode("Storage controllers");
            TreeNode item18 = new TreeNode("System devices");
            TreeNode item19 = new TreeNode("Universal Serial Bus controllers");
            TreeNode[] array = new TreeNode[] { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19 };
            TreeNode user = new TreeNode(label28.Text, array);
            treeView1.Nodes.Add(user);
            user.Expand();

            ManagementObjectSearcher soundDev = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            foreach (ManagementObject soundDevData in soundDev.Get())
            {
                TreeNode sound;
                if (soundDevData["ProductName"] != null)
                {
                    sound = new TreeNode(soundDevData["ProductName"].ToString());
                    item16.Nodes.Add(sound);
                }
            }
            ManagementObjectSearcher videoDev = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject videoDevData in videoDev.Get())
            {
                TreeNode video;
                if (videoDevData["Name"] != null)
                {
                    video = new TreeNode(videoDevData["Name"].ToString());
                    item16.Nodes.Add(video);
                }
            }


            ManagementObjectSearcher diskDev = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject diskDevData in diskDev.Get())
            {
                TreeNode disk;
                if (diskDevData["Model"] != null)
                {
                    disk = new TreeNode(diskDevData["Model"].ToString());
                    item3.Nodes.Add(disk);
                }
            }
            ManagementObjectSearcher networkDev = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");
            foreach (ManagementObject networkDevData in networkDev.Get())
            {
                TreeNode network;
                if (networkDevData["Name"] != null)
                {
                    network = new TreeNode(networkDevData["Name"].ToString());
                    item11.Nodes.Add(network);
                }
            }
            ManagementObjectSearcher procDev = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject procDevData in procDev.Get())
            {
                TreeNode proc;
                if (procDevData["Name"] != null)
                {
                    proc = new TreeNode(procDevData["Name"].ToString());
                    item13.Nodes.Add(proc);
                }
            }
            ManagementObjectSearcher dispDev = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
            foreach (ManagementObject dispDevData in dispDev.Get())
            {
                TreeNode disp;
                if (dispDevData["DeviceName"] != null)
                {
                    disp = new TreeNode(dispDevData["DeviceName"].ToString());
                    item4.Nodes.Add(disp);
                }
            }
            ManagementObjectSearcher CDDev = new ManagementObjectSearcher("SELECT * FROM Win32_CDROMDrive");
            foreach (ManagementObject CDDevData in CDDev.Get())
            {
                TreeNode CD;
                if (CDDevData["Name"] != null)
                {
                    CD = new TreeNode(CDDevData["Name"].ToString());
                    item5.Nodes.Add(CD);
                }
            }
            ManagementObjectSearcher IDEDev = new ManagementObjectSearcher("SELECT * FROM Win32_IDEController");
            foreach (ManagementObject IDEDevData in IDEDev.Get())
            {
                TreeNode IDE;
                if (IDEDevData["Name"] != null)
                {
                    IDE = new TreeNode(IDEDevData["Name"].ToString());
                    item7.Nodes.Add(IDE);
                }
            }
            ManagementObjectSearcher keyboardDev = new ManagementObjectSearcher("SELECT * FROM Win32_Keyboard");
            foreach (ManagementObject keyboardDevData in keyboardDev.Get())
            {
                TreeNode keyboard;
                if (keyboardDevData["Description"] != null)
                {
                    keyboard = new TreeNode(keyboardDevData["Description"].ToString());
                    item8.Nodes.Add(keyboard);
                }
            }
            ManagementObjectSearcher mouseDev = new ManagementObjectSearcher("SELECT * FROM Win32_PointingDevice");
            foreach (ManagementObject mouseDevData in mouseDev.Get())
            {
                TreeNode mouse;
                if (mouseDevData["Description"] != null)
                {
                    mouse = new TreeNode(mouseDevData["Description"].ToString());
                    item9.Nodes.Add(mouse);
                }
            }
            ManagementObjectSearcher monitorDev = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
            foreach (ManagementObject monitorDevData in monitorDev.Get())
            {
                TreeNode monitor;
                if (monitorDevData["Description"] != null)
                {
                    monitor = new TreeNode(monitorDevData["Description"].ToString());
                    item10.Nodes.Add(monitor);
                }
            }
            ManagementObjectSearcher printerDev = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printerDevData in printerDev.Get())
            {
                TreeNode printer;
                if (printerDevData["Name"] != null)
                {
                    printer = new TreeNode(printerDevData["Name"].ToString());
                    item12.Nodes.Add(printer);
                }
            }
            ManagementObjectSearcher USBDev = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            foreach (ManagementObject USBDevData in USBDev.Get())
            {
                TreeNode USB;
                if (USBDevData["Name"] != null)
                {
                    USB = new TreeNode(USBDevData["Name"].ToString());
                    item19.Nodes.Add(USB);
                }
            }
            ManagementObjectSearcher systDev = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject systDevData in systDev.Get())
            {
                TreeNode syst;
                if (systDevData["Description"] != null)
                {
                    syst = new TreeNode(systDevData["Name"].ToString());
                    item18.Nodes.Add(syst);
                }
            }
            ManagementObjectSearcher sDev = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject sDevData in sDev.Get())
            {
                TreeNode s;
                if (sDevData["SystemType"] != null)
                {
                    s = new TreeNode(sDevData["SystemType"].ToString());
                    item2.Nodes.Add(s);
                }
            }

            /*
                    ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(
                                       "SELECT * FROM Win32_PnPEntity");

                    ManagementObjectCollection objCollection = objSearcher.Get();

                    foreach (ManagementObject obj in objCollection)
                    {
                        foreach (PropertyData property in obj.Properties)
                        {
                            property.
                            Console.Out.WriteLine(String.Format("{0}:{1}", property.Name, property.Value));
                        }
                    }
            */

            ManagementObjectSearcher USB2Dev = new ManagementObjectSearcher("SELECT * FROM Win32_USBController");
            foreach (ManagementObject USBDevData in USB2Dev.Get())
            {
                TreeNode USB;
                if (USBDevData["Name"] != null)
                {
                    USB = new TreeNode(USBDevData["Name"].ToString());
                    item19.Nodes.Add(USB);
                }
            }

        }
            



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // select local computer
                ManagementScope ManScope = new ManagementScope(@"\\localhost\root\default");
                // create system restore point
                ManagementPath ManPath = new ManagementPath("SystemRestore");
                // select default options
                ObjectGetOptions ManOptions = new ObjectGetOptions();
                // create management class with previous options
                ManagementClass ManClass = new ManagementClass(ManScope, ManPath, ManOptions);
                // load function parameters
                ManagementBaseObject ManBaseObject = ManClass.GetMethodParameters("CreateRestorePoint");
                // description : The description to be displayed so the user can easily identify a restore point.
                ManBaseObject["Description"] = "Recovery Point";
                // type of the restore point : APPLICATION_INSTALL - 0 - An application has been installed.
                ManBaseObject["RestorePointType"] = 0;
                // type of the event : BEGIN_SYSTEM_CHANGE - 100 -A system change has begun.
                ManBaseObject["EventType"] = 100;

                ManagementBaseObject OutParam = ManClass.InvokeMethod("CreateRestorePoint", ManBaseObject, null);

                // List outParams
                Console.WriteLine("Out parameters:");
                Console.WriteLine("ReturnValue: " + OutParam["ReturnValue"]);
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






    }



}