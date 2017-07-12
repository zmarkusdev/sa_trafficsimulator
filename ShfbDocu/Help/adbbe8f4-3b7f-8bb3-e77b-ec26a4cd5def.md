# AgentRepository.DrawAgents Method 
 

Deletes all existing AgentModels and creates new ones with the given position, edge and agens information

**Namespace:**&nbsp;<a href="65763977-2250-51c1-3f4f-8c5da206e5aa">SimulationUserInterface.Models</a><br />**Assembly:**&nbsp;SimulationUserInterface (in SimulationUserInterface.exe) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public void DrawAgents(
	IEnumerable<Position> positions,
	IEnumerable<Edge> edges,
	IEnumerable<Agent> agents
)
```


#### Parameters
&nbsp;<dl><dt>positions</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">System.Collections.Generic.IEnumerable</a>(<a href="ededcdcd-3dcf-e8df-8419-0febda6b6b89">Position</a>)<br />Positions from the DataBridge</dd><dt>edges</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">System.Collections.Generic.IEnumerable</a>(<a href="19be5487-4623-807c-776e-93934534c2f8">Edge</a>)<br />Edges from the DataBridge</dd><dt>agents</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">System.Collections.Generic.IEnumerable</a>(<a href="87bd37bb-4841-462c-dac2-4b100399bf06">Agent</a>)<br />Agents from the DataBridge</dd></dl>

## See Also


#### Reference
<a href="46387967-c468-40a8-9904-13f25d58f794">AgentRepository Class</a><br /><a href="65763977-2250-51c1-3f4f-8c5da206e5aa">SimulationUserInterface.Models Namespace</a><br />