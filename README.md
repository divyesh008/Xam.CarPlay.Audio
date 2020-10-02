# Xam.CarPlay.Audio
 CarPlay Audi App Sample

#### CarPlay audio apps are controlled by the MPPlayableContentManager. You are required to implement the MPPlayableContentDelegate and MPPlayableContentDatasource protocol in order to connect with CarPlay. The UI is controlled by CarPlay - all you need to do is feed it data for tabs+tables (datasource) and respond to playable items (delegate).

## How to get NowPlaying Screen?
To get the NowPlaying screen you have to set two things without fail.
- MPRemoteCommandCenter
```css
var commandCenter = MPRemoteCommandCenter.Shared;
commandCenter.PlayCommand.Enabled = true;
commandCenter.StopCommand.Enabled = true;
```
- MPPlayableContentManager.NowPlayingIdentifiers 
```css
var urlId = "11111";
string[] identifier = new string[1];
identifier[0] = urlId;

contentManager = MPPlayableContentManager.Shared;
contentManager.NowPlayingIdentifiers = identifier;
```

### For More Reference
- [Car Play Guide](https://developer.apple.com/carplay/documentation/CarPlay-App-Programming-Guide.pdf)
- [Car Play Audio App Guide](https://developer.apple.com/carplay/documentation/CarPlay-Audio-App-Programming-Guide.pdf)


## Output:

![](name-of-giphy.gif)
