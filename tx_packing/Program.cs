using TXTextControl.DocumentServer;

using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
{
	tx.Create();
	tx.Load("packing_slip.tx", TXTextControl.StreamType.InternalUnicodeFormat);

	MailMerge mailMerge = new MailMerge()
	{
		TextComponent = tx
	};

	string jsonData = System.IO.File.ReadAllText("data.json");

	mailMerge.MergeJsonData(jsonData);

	tx.Save("output.pdf", TXTextControl.StreamType.AdobePDF);
}