﻿namespace Literature.Works.Api.Options;

public class RabbitMq
{
    public string HostName { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Queue { get; set; }
}