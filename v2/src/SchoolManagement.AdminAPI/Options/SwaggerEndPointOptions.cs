namespace SchoolManagement.AdminAPI.Options;

public class SwaggerEndPointOptions
{
	public const string ConfigurationSectionName = "SwaggerEndPoints";

	public List<SwaggerEndPointConfig>? Config { get; set; }
}

public class SwaggerEndPointConfig
{
	public string? Name { get; set; }
	public string? Version { get; set; }
	public string? Url { get; set; }
}