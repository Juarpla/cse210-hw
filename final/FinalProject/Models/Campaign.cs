using System;

class Campaign
{
    private string _name;
    private List<Clientele> _clientele;

    public Campaign(string name)
    {
        _name = name;
        _clientele = new List<Clientele>();
    }
    public string GetName()
    {
        return _name;
    }
    public List<Clientele> GetClientele()
    {
        return _clientele;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetClientele(List<Clientele> clientele)
    {
        foreach (Clientele person in clientele)
        {
            _clientele.Add(person);
        }
    }
}