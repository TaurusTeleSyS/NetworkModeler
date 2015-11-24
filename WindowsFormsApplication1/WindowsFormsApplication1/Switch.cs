class Switch
{
    public string SwitchName { get; }
    public NetworkInterface[] Ports { get; }
    public int PortCount { get; }

    public Switch(string name, int PortNum)
    {
        SwitchName = name;
        PortCount = PortNum;

        for (int i = 0; i < PortCount; i++)
        { Ports[i] = new NetworkInterface(SwitchName + "_interface_" + i); }
    }
}