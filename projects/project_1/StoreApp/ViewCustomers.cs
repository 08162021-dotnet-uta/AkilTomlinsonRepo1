namespace StoreApp
{
  public class ViewCustomers
  {
    private string firstname;
    public string Firstname
    {
      get
      {
        return firstname;
      }
      set
      {
        if (value.Length > 50 || value.Length == 0)
        {
          this.firstname = "Invalid Input";
        }
        else
        {
          this.firstname = value;
        }

      }
    }
    public string Lastname { get; set; }
  }//EoC

}//EoF