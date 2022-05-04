﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;
using Ahnduino.Lib;

namespace Ahnduino.Wins
{
	/// <summary>
	/// ResetPW.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class ResetPW : Window
	{
		Firebase firebase = new();

		public ResetPW()
		{
			InitializeComponent();
		}

		private void RegBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!firebase.FindId(emailtextbox.Text))
				{
					MessageBox.Show("이메일을 찾을 수 없습니다");
					return;
				}
					

				MailMessage msg = new MailMessage("highfuncsmtp@gmail.com", emailtextbox.Text,
		  "Subject : Reset Ahnduino Password", "새 비밀번호:" + firebase.ResetEmail(emailtextbox.Text));

				SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
				smtp.EnableSsl = true;


				smtp.Credentials = new NetworkCredential("highfuncsmtp@gmail.com", "opli6554");

				smtp.Send(msg);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}
	}
}
