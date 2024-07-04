﻿namespace Domain.Models;

public class EmailOptions
{
    public string MailServer { get; set; }
    public int MailPort { get; set; }
    public string SenderName { get; set; }
    public string FromEmail { get; set; }
    public string Password { get; set; }

}
