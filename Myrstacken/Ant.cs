class Ant
{
    private int legs;
    private string name;


    public Ant(int legs, string name)
    {
        this.legs = legs;
        this.name = name;

        this.name = this.name[0].ToString().ToUpper() + this.name.Substring(1, this.name.Length - 1);

    }
    
    /// Not using
    //public void SetLegs(int legs)
    //{
    //    this.legs = legs;
    //}

    public int GetLegs()
    {
        return legs;
    }
    

    /// Not using
    //public void SetName(string name)
    //{
    //    this.name = name;
    //}

    public string GetName()
    {
        return this.name;
    }
}