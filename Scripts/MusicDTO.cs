using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MusicDTO : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }


namespace NoteEditor.DTO
{
    public class MusicDTO
    {
        [System.Serializable]
        public class EditData
        {
            public string name;
            public int BPM;
            public string composer;
            public List<Note> notes;
        }

        [System.Serializable]
        public class Note
        {
            //public int LPB;
            //public int num;
            //public int block;
            public int line;
            public int type;
            public float timing;
            //public List<Note> notes;
        }
    }
}