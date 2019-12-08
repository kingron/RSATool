using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSATool
{
	public partial class MainForm : Form
	{
		const string FILTER_KEYS = "密钥文件(*.xkey)|*.xkey|全部文件(*.*)|*.*";

		public MainForm()
		{
			InitializeComponent();
		}

		bool SaveStringToFile(string file, string text)
		{
			try
			{
				File.WriteAllText(file, text);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			string PrivateKey, PublicKey;
			SaveFileDialog dlgOpen = new SaveFileDialog();
			dlgOpen.Filter = FILTER_KEYS;
			RSACryption.RSAKey(out PrivateKey, out PublicKey);

			if (dlgOpen.ShowDialog() == DialogResult.OK && SaveStringToFile(dlgOpen.FileName, PrivateKey))
			{
				tbPrivateKey.Text = PrivateKey;
				tbPublicKey.Text = PublicKey;
			}
		}

		private void DlgError(string msg) => MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			try
			{
				tbResult.Text = RSACryption.RSAEncrypt(tbPrivateKey.Text, tbClientPublicKey.Text, tbSource.Text);
			}
			catch (Exception ex)
			{
				tbResult.Text = "加密失败: " + ex.Message;
			}
		}

		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			try
			{
				tbResult.Text = RSACryption.RSADecrypt(tbPrivateKey.Text, tbClientPublicKey.Text, tbSource.Text);
			}
			catch (Exception ex)
			{
				tbResult.Text = "请确保加对方用我的公钥加密，解密失败: " + ex.Message;
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			dlgOpen.Filter = FILTER_KEYS;
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				string key = File.ReadAllText(dlgOpen.FileName);
				System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
				rsa.FromXmlString(key);
				tbPrivateKey.Text = key;
				tbPublicKey.Text = rsa.ToXmlString(false);
			}
		}
	}
}
