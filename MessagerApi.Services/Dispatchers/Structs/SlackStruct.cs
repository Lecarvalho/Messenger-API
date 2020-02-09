using System.Collections.Generic;
using Newtonsoft.Json;

public struct SlackStruct
{
    public SlackStruct(string content, string user)
    {
        blocks = new List<IBloc>()
        {
            new Section(content),
            new Context(user)
        };
    }
    public List<IBloc> blocks { get; set; }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public interface IBloc
{
    string type {get;}
}

public struct Section : IBloc
{
    public Section(string content)
    {
        text = new Text(content);
    }
    public Text text { get; set; }

    public string type => "section";
}

public struct Context : IBloc
{
    public Context(string user)
    {
        elements = new List<Text>
        {
            new Text("*User:* " + user)
        };
    }
    
    public List<Text> elements { get; set; }

    public string type => "context";
}

public struct Image : IBloc
{
    public Image(string imageUrl)
    {
        image_url = imageUrl;
    }
    public string type => "image";
    public string image_url { get; set; }
    public string alt_text => "image";

}

public struct Text
{
    public Text(string text)
    {
        this.text = text;
    }
    public string type { get { return "mrkdwn"; } }
    public string text { get; set; }
}