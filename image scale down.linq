<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
</Query>

void Main()
{
	var files = Directory.GetFiles(@"", "*.jpg");
	var target = @"";

	foreach (var file in files)
	{
		var thumb = Path.Combine(target, Path.GetFileName(file));

		var img = Image.FromFile(file);

		CompressAndSaveImage(img, thumb, 5);
	}

}

private void CompressAndSaveImage(Image img, string fileName,
		long quality)
{
	EncoderParameters parameters = new EncoderParameters(1);
	parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
	img.Save(fileName, GetCodecInfo("image/jpeg"), parameters);
}

private static ImageCodecInfo GetCodecInfo(string mimeType)
{
	foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
		if (encoder.MimeType == mimeType)
			return encoder;
	throw new ArgumentOutOfRangeException(
		string.Format("'{0}' not supported", mimeType));
}

// Define other methods and classes here
