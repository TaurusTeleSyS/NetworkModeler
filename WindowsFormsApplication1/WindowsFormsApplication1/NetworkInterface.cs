class NetworkInterface
{
    public string Name { get; }
    public bool IsConnected => Link != null;
    public NetworkInterface Link { get; private set; }

    public NetworkInterface(string name)
    {
        Name = name;
    }

    private void ConnectToInternal(NetworkInterface networkInterface)
    {
        // Seporate method for setting Link variable to make it easier to bidirectionally link NetworkInterfaces
        Link = networkInterface;
    }

    public void SetConnection(NetworkInterface networkInterface)
    {
        if (networkInterface == null)
        {
            throw new System.ArgumentNullException("Can't connect to null network interface", nameof(networkInterface));
        }

        ConnectToInternal(networkInterface);
        networkInterface.ConnectToInternal(this);
    }

    public void Disconnect()
    {
        // Only call ConnectToInternal on Link if Link != null ... Basic error handeling
        Link?.ConnectToInternal(null);
        Link = null;
    }
}