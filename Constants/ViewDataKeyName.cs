namespace Constants;

public static class ViewDataKeyName : object
{
	static ViewDataKeyName()
	{
	}

	public static string PageTitle
	{
		get
		{
			return "PageTitle";
		}
	}

	public static class OpenGraph : object
	{
		public static string Title
		{
			get
			{
				return "OpenGraph.Title";
			}
		}

		public static string Description
		{
			get
			{
				return "OpenGraph.Description";
			}
		}

		public static string Image
		{
			get
			{
				return "OpenGraph.Image";
			}
		}

		public static string ImageAlt
		{
			get
			{
				return "OpenGraph.Image.Alt";
			}
		}
	}
}
