# IDataManager.GetSuccessorEdges Method 
 

Returns all successors for a given edge.

**Namespace:**&nbsp;<a href="699cd2d6-1481-41f2-ef8c-776ba4af1388">DataManager</a><br />**Assembly:**&nbsp;DataManager (in DataManager.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
IReadOnlyList<Edge> GetSuccessorEdges(
	int edgeId
)
```


#### Parameters
&nbsp;<dl><dt>edgeId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The id of the edge you want to know the successors for</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/hh192385" target="_blank">IReadOnlyList</a>(<a href="19be5487-4623-807c-776e-93934534c2f8">Edge</a>)<br />Read-only list of successor edges

## See Also


#### Reference
<a href="46cd8405-1684-f638-1174-ea05d804b4a7">IDataManager Interface</a><br /><a href="699cd2d6-1481-41f2-ef8c-776ba4af1388">DataManager Namespace</a><br />