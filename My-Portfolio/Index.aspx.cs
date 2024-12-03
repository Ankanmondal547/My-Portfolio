using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Portfolio
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessMessage.Text = string.Empty;
        }
        protected void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Configure the email details
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("ankanmondal547@gmail.com");
                    mailMessage.To.Add("ankanmondal547@gmail.com"); // Replace with recipient's email
                    mailMessage.Subject = SubjectTextBox.Text;
                    mailMessage.Body = $"Name: {NameTextBox.Text}\nEmail: {EmailTextBox.Text}\nMessage: {MessageTextBox.Text}";

                    // Configure the SMTP client
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Replace with your SMTP server
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential("ankanmondal547@gmail.com", "qvpo ukpi ijnh ysui");
                    smtpClient.EnableSsl = true;

                    // Send the email
                    smtpClient.Send(mailMessage);

                    // Display success message
                    SuccessMessage.Text = "Your message has been sent successfully!";
                }
                catch (Exception ex)
                {
                    SuccessMessage.Text = $"Error sending message: {ex.Message}";
                }
            }
        }
        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            // Path to the PDF file you want to download
            string filePath = Server.MapPath("~/Resume/Resume Ankan.pdf");

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                // Clear the current output content from the buffer
                Response.Clear();

                // Set the response type to PDF
                Response.ContentType = "application/pdf";

                // Add a header to prompt download with a filename
                Response.AddHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));

                // Write the file to the response output stream
                Response.WriteFile(filePath);

                // End the response to ensure no further content is sent
                Response.End();
            }
            else
            {
                // Optionally handle if the file does not exist
                Response.Write("File not found.");
            }
        }

    }
}