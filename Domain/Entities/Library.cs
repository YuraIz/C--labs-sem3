using System.Collections.Generic;
using System.Xml.Serialization;
namespace Domain.Entities;
[Serializable]
public class Library : List<BookDepository>
{

}
