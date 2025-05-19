
using TXTextControl;
using TXTextControl.DocumentServer;

using (ServerTextControl tx = new ServerTextControl())
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