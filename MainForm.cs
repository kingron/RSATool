using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RSATool
{
	public partial class MainForm : Form
	{
		const string FILTER_KEYS = "密钥文件(*.xkey, *.pem)|*.xkey;*.pem;*.key|全部文件(*.*)|*.*";

		public MainForm()
		{
			InitializeComponent();
			rtfAbout.Rtf = @"{\rtf1\ansi\ansicpg936\deff0\nouicompat\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'b5\'c8\'cf\'df;}{\f1\fnil\fcharset134 \'cb\'ce\'cc\'e5;}{\f2\fnil\fcharset2 Symbol;}}
{\colortbl ;\red0\green0\blue255;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\sa200\sl276\slmult1\qc\b\f0\fs52\lang2052\'b9\'d8\'d3\'daRSATools\par
\b0\f1\fs22\'b0\'e6\'c8\'a8\'cb\'f9\'d3\'d0\u169? 2020\'a3\'acKingron\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sa200\sl276\slmult1\'c1\'aa\'cf\'b5\'b7\'bd\'ca\'bd\par
\pard\li720\sa200\sl276\slmult1 {{\field{\*\fldinst{HYPERLINK https://github.com/kingron/RSATool }}{\fldrslt{https://github.com/kingron/RSATool\ul0\cf0}}}}\f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sa200\sl276\slmult1\'d6\'c2\'d0\'bb\par
\pard{\pntext\f1 1.\tab}{\*\pn\pnlvlbody\pnf1\pnindent0\pnstart1\pndec{\pntxta.}}
\fi-360\li1080\sa200\sl276\slmult1 Cyber Attack\'a3\'ac\'cc\'e1\'b9\'a9\'c1\'cbApp\'cd\'bc\'b1\'ea\par
{\pntext\f1 2.\tab}JavaScience Consulting, Michel Gallant\'a3\'acPEM\'c3\'dc\'d4\'bf\'b6\'c1\'c8\'a1\par
{\pntext\f1 2.\tab}Github\'a3\'ac\'cc\'e1\'b9\'a9\'c1\'cb\'b4\'fa\'c2\'eb\'cd\'d0\'b9\'dc\par
}
 ";
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
				tbResult.Text = "请确保对方用我的公钥加密，解密失败: " + ex.Message;
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			string key;
			dlgOpen.Filter = FILTER_KEYS;
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				RSACryptoServiceProvider rsa = PemKeyUtils.GetRSAProviderFromPemFile(dlgOpen.FileName);
				if (rsa == null)
				{
					key = File.ReadAllText(dlgOpen.FileName);
					rsa = new RSACryptoServiceProvider();
					rsa.FromXmlString(key);
				}
				tbPrivateKey.Text = rsa.ToXmlString(true);
				tbPublicKey.Text = rsa.ToXmlString(false);
			}
		}

		private void btnEncFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			SaveFileDialog dlgSave = new SaveFileDialog();
			if (dlgOpen.ShowDialog() != DialogResult.OK || dlgSave.ShowDialog() != DialogResult.OK) return;

			Application.UseWaitCursor = true;
			Application.DoEvents();
			try
			{
				RSACryption.RSAEncrypt(tbPrivateKey.Text, tbClientPublicKey.Text, dlgOpen.FileName, dlgSave.FileName);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Application.UseWaitCursor = false;
			}
		}


		private void btnDecFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			SaveFileDialog dlgSave = new SaveFileDialog();
			if (dlgOpen.ShowDialog() != DialogResult.OK || dlgSave.ShowDialog() != DialogResult.OK) return;

			Application.UseWaitCursor = true;
			Application.DoEvents();
			try
			{
				RSACryption.RSADecrypt(tbPrivateKey.Text, tbClientPublicKey.Text, dlgOpen.FileName, dlgSave.FileName);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Application.UseWaitCursor = false;
			}
		}

		private void rtfAbout_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}

		private void btnLoadPubKey_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			dlgOpen.Filter = "公钥文件(*.pub, *.pem)|*.pub;*.pem|全部文件(*.*)|*.*"; ;
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				RSACryptoServiceProvider rsa = PemKeyUtils.GetRSAProviderFromPemFile(dlgOpen.FileName);
				if (rsa == null)
				{
					string s = File.ReadAllText(dlgOpen.FileName);
					if (s.StartsWith("ssh-rsa "))
					{
						string[] ss = s.Split(' ');
						rsa = PemKeyUtils.DecodeX509PublicKey(ss[1]);
					}
					else
					{
						rsa = new RSACryptoServiceProvider();
						rsa.FromXmlString(s);
					}
				}
				if (rsa != null)
					tbClientPublicKey.Text = rsa.ToXmlString(false);
				else
					DlgError("密钥加载失败，仅支持xkey，x509格式以及pem格式密钥。\n支持ssh-keygen生成的密钥。");
			}
		}
	}
}
