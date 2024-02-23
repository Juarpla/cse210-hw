using System;

abstract class Clientele
{
    private string _name;
    private string _contactInfo;

    public Clientele(string name, string contactInformation)
    {
        _name = name;
        _contactInfo = contactInformation;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetContactInfo()
    {
        return _contactInfo;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetContactInformation(string contactInformation)
    {
        _contactInfo = contactInformation;
    }
}