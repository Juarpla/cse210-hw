using System;

class CRMSystem
{
    private List<Client> _clients;
    private List<Lead> _leads;
    private List<FormerClient> _formers;
    private List<Campaign> _campaign;

    public CRMSystem()
    {
        _clients = new List<Client>();
        _leads = new List<Lead>();
        _formers = new List<FormerClient>();
        _campaign = new List<Campaign>();
    }

    public void AddCampaign(Campaign campaign)
    {
        _campaign.Add(campaign);
    }

    public void AddClient(Client client)
    {
        _clients.Add(client);
    }

    public void AddLead(Lead lead)
    {
        _leads.Add(lead);
    }

    public void AddFormer(FormerClient formerClient)
    {
        _formers.Add(formerClient);
    }

    public List<Client> GetClients()
    {
        return _clients;
    }

    public List<Campaign> GetCampaigns()
    {
        return _campaign;
    }

    public List<Lead> GetLeads()
    {
        return _leads;
    }

    public List<FormerClient> GetFormerClients()
    {
        return _formers;
    }

    public void AddClients(List<Client> clients)
    {
        foreach (Client client in clients)
        {
            _clients.Add(client);
        }
    }

    public void AddLeads(List<Lead> leads)
    {
        foreach (Lead lead in leads)
        {
            _leads.Add(lead);
        }
    }

    public void AddFormers(List<FormerClient> formersClient)
    {
        foreach (FormerClient former in formersClient)
        {
            _formers.Add(former);
        }
    }

    public void AddCampaigns(List<Campaign> campaigns)
    {
        foreach (Campaign campaign in campaigns)
        {
            _campaign.Add(campaign);
        }
    }
}