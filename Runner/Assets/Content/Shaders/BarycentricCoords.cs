using UnityEngine;
using System.Collections;

public class BarycentricCoords : MonoBehaviour
{
	[SerializeField] bool _flatNormals = true;
	
	static int lastRunFrame = -1;
	IEnumerator Start()
	{
		while ( lastRunFrame == Time.frameCount )
		{
			yield return null;
		}
		
		//Debug.LogError ("BarycentricCoords " + this.gameObject.name + " " + Time.frameCount);
		lastRunFrame = Time.frameCount;
		MeshFilter meshfilter = GetComponent<MeshFilter> ();
		
		Mesh sourceMesh = meshfilter.sharedMesh;
		
		int[] sourceIndices = sourceMesh.GetTriangles( 0 );
		Vector3[] sourceVerts = sourceMesh.vertices;
		Vector3[] sourceNormals = sourceMesh.normals;
		Vector2[] sourceUVs = sourceMesh.uv;
		
		int[] newIndices = new int[sourceIndices.Length];
		Vector3[] newVertices = new Vector3[sourceIndices.Length];
		Vector3[] newNormals = new Vector3[sourceIndices.Length];
		Vector2[] newUVs = new Vector2[sourceIndices.Length];
		Color[] newColors = new Color[sourceIndices.Length];
		
		Color[] colors = new Color[] { Color.red, Color.blue, Color.green };
		float[] random = new float[sourceIndices.Length / 3];
		
		for ( int i = 0; i < random.Length; ++i )
		{
			random [i] = //Random.value;
			
			    sourceVerts[sourceIndices[i * 3]].z / sourceMesh.bounds.extents.z;
		}
		
		// Create a unique vertex for every index in the original Mesh:
		for ( int i = 0; i < sourceIndices.Length; i++ )
		{
			newIndices[i] = i;
			newVertices[i] = sourceVerts[sourceIndices[i]];
			newUVs[i] = sourceUVs[sourceIndices[i]];
			newColors [i] = colors [i % 3];
			
			if ( _flatNormals )
			{
				Vector3 normal = sourceNormals [sourceIndices [i - ( i % 3 )]];
				newNormals [i] = normal;
			}
			else
			{
				newNormals[i] = sourceNormals[sourceIndices[i]];
			}
			
			Color c = newColors [i];
			c.a = random[( i - ( i % 3 ) ) / 3];
			
			newColors [i] = c;
		}
		
		Mesh unsharedVertexMesh = new Mesh();
		unsharedVertexMesh.vertices = newVertices;
		unsharedVertexMesh.uv = newUVs;
		unsharedVertexMesh.colors = newColors;
		unsharedVertexMesh.normals = newNormals;
		
		unsharedVertexMesh.SetTriangles( newIndices, 0 );
		
		meshfilter.mesh = unsharedVertexMesh;
	}
}
