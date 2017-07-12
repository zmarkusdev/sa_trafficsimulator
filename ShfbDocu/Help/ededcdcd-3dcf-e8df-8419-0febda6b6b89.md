# Position Class
 

A position of the map is a node on the graph model. Positions also define the starting and end points of the edges in pixel coordinates


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="4dd8c2e5-2def-208c-c36a-25c6577b34e3">Datamodel.BaseModel</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Datamodel.Position<br />
**Namespace:**&nbsp;<a href="a489f29d-64b3-9193-8c03-5c66a32a78aa">Datamodel</a><br />**Assembly:**&nbsp;DataModel (in DataModel.exe) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public class Position : BaseModel
```

The Position type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="7f49365e-1956-6583-d2f9-8bcda8864e7a">Position</a></td><td>
Initializes a new instance of the Position class</td></tr></table>&nbsp;
<a href="#position-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="21e16472-3244-ca38-97fa-5b47c8d1c025">Id</a></td><td>
Unique identifier for the current model object
 (Inherited from <a href="4dd8c2e5-2def-208c-c36a-25c6577b34e3">BaseModel</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="f64eaf75-115a-15cc-c123-335e6e860664">IsRemoteEntryPoint</a></td><td>
Marks the current Position as remote entry point from another simulation</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="152917b5-20fc-a158-3faa-dcfdad7955d2">MaxVelocity</a></td><td>
Max velocity allowed around this position in m/s (deprecated)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="9cdbc6ae-151a-46b9-865d-9fa8780498bb">PredecessorEdgeIds</a></td><td>
Collection of edge ids that go into this position (predecessors)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="94f3d3ed-54b0-ae07-d371-edb13941b76f">Rotation</a></td><td>
Rotation in degrees cars have on this position (deprecated)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="9655ea71-cafd-0eb5-cac6-1bf5621d6502">RuleIds</a></td><td>
List of rules that need to be considered when on this position (deprecated)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="45d84757-0910-fe4a-8f8c-fd43646a369f">SuccessorEdgeIds</a></td><td>
List of edge ids that come after this position (successors)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="9f583439-08e9-d886-f771-2e9b64d54e87">Transfer</a></td><td>
Marks the position as remote transfer edge, if a agent passes this position and the transfer is set, the agent will be transferred to another simulation.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="4c059d8f-3518-1f8d-e48a-e8cc41fa0808">X</a></td><td>
x coordinate of the position on the map in pixels</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="9e356a14-df72-e78a-cc02-592af62e3ccb">Y</a></td><td>
y coordinate of the position on the map in pixels</td></tr></table>&nbsp;
<a href="#position-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#position-class">Back to Top</a>

## See Also


#### Reference
<a href="a489f29d-64b3-9193-8c03-5c66a32a78aa">Datamodel Namespace</a><br />