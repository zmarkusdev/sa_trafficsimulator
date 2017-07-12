# MainWindowModel Class
 

Window Model holding the connection to the UI


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Technics.Model</a><br />&nbsp;&nbsp;&nbsp;&nbsp;SimulationUserInterface.Models.MainWindowModel<br />
**Namespace:**&nbsp;<a href="65763977-2250-51c1-3f4f-8c5da206e5aa">SimulationUserInterface.Models</a><br />**Assembly:**&nbsp;SimulationUserInterface (in SimulationUserInterface.exe) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public class MainWindowModel : Model
```

The MainWindowModel type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="e5615830-e76e-8203-130f-a6ae23d6c905">MainWindowModel</a></td><td>
Default constructor which sets the image size of the application for the first time</td></tr></table>&nbsp;
<a href="#mainwindowmodel-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="582b2d65-0cc3-e298-8976-52abd8af347e">BackgroundMap</a></td><td>
Background map</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="4908ce55-51be-56ef-b294-0881f5a37140">BackgroundMapHeight</a></td><td>
Heigth of the background map</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="20febde2-43ec-bec9-252a-1e95c0081160">BackgroundMapWidth</a></td><td>
Width of the background map</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="f74f3680-ae9a-60a8-f7dd-d3eae46f644b">CreatePoint</a></td><td>
Test command to show a click</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="8084271e-8126-111e-351d-223e3c798820">Error</a></td><td>

 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="f5043540-aad0-d214-60bc-93d6bb0127ed">Item</a></td><td>

 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="a80ea99a-7d9a-d629-3bd2-7ab3b152fe30">NetEnabled</a></td><td>
Flag that shows/hide the positions and edges of the street map</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="136cc238-35bd-f73c-2621-597321d4517c">WindowHeight</a></td><td>
Current window height</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="c3b9c33f-0d84-9b55-565a-a8e3246d0a57">WindowWidth</a></td><td>
Current window width</td></tr></table>&nbsp;
<a href="#mainwindowmodel-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="df803fa3-ee92-bc5c-c874-a8574cdea728">GetImageFactor</a></td><td>
Returns the new image resize factors for x and y if the window is resized by the user</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="b5252d2d-7b55-43e8-ef1e-29f59398a737">OnPropertyChanged(TProperty)</a></td><td>
Updates the variable (called from XAML)
 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="c94d4f78-3dfd-3bb4-42be-8d161806bf24">RaisePropertyChanged</a></td><td>
Updates the User Interface property
 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="5dba8235-9544-e09b-eec1-697c1774fcd7">SetBackgroundInformation</a></td><td>
Sets the Background information for a new background image</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="9270cb2f-a7d8-9913-c21c-cd2f6783d8c2">Validate</a></td><td>

 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr></table>&nbsp;
<a href="#mainwindowmodel-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="d26a5522-e8f3-039b-41e0-5260dc2716f9">PropertyChanged</a></td><td>
Property event handler for User Interface updates
 (Inherited from <a href="d1bc9265-c35d-6d47-b537-7d1e1034dd46">Model</a>.)</td></tr></table>&nbsp;
<a href="#mainwindowmodel-class">Back to Top</a>

## See Also


#### Reference
<a href="65763977-2250-51c1-3f4f-8c5da206e5aa">SimulationUserInterface.Models Namespace</a><br />