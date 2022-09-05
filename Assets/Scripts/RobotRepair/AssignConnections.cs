using UnityEngine;

public class AssignConnections : MonoBehaviour
{
    // private List<Material> connectionList = new List<Material>();
    private Renderer[] children;
    public Material[] connections;
    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<Renderer>();
        
        AssignRandomMaterials(children, connections);
    }

    void AssignRandomMaterials(Renderer[] renderers, Material[] materials) {
        System.Random r = new System.Random();
        int splitArray = renderers.Length / 2;
        for (int i = splitArray - 1; i > 0; i--) {
            int j = r.Next(0, i+1);
            Renderer temp = renderers[i];
            renderers[i] = renderers[j];
            renderers[j] = temp;
        }
        for (int i = renderers.Length - 1; i > splitArray; i--) {
            int j = r.Next(splitArray, i+1);
            Renderer temp = renderers[i];
            renderers[i] = renderers[j];
            renderers[j] = temp;
        }

        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].material = materials[i];
        }
    }

}
