namespace CrudFornecedores.Models
{

	public class ResponsePloomes
	{
		public List<Value> value { get; set; }
	}

	public class Value
	{
		public int Id { get; set; }
	}

	public class OtherProperty
	{
		public string FieldKey { get; set; }
		public object StringValue { get; set; }
		public object IntegerValue { get; set; }
		public object BigStringValue { get; set; }
	}

	public class Root
	{
		public List<OtherProperty> OtherProperties { get; set; }
		public int ContactId { get; set; }
		public object DealId { get; set; }
		public string Date { get; set; }
		public List<object> Contacts { get; set; }
		public List<object> Tags { get; set; }
		public string Content { get; set; }
		public List<object> NotifiedUsers { get; set; }
		public int TypeId { get; set; }
	}
}