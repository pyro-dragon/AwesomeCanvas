using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeCanvas
{
    public class History : IEnumerable<Dictionary<string, object>>
    {
        List<UndoLevel> undoLevels = new List<UndoLevel>();
        class UndoLevel
        {
            public List<Dictionary<string, object>> commands = new List<Dictionary<string, object>>();
        }
        UndoLevel current {
            get { return undoLevels[undoLevels.Count - 1]; }
        }
        public void StoreUndoData(Dictionary<string, object> pData) {
            if (undoLevels.Count == 0)
                BeginNewUndoLevel();

            current.commands.Add(pData);
        }
        public void BeginNewUndoLevel() {
            undoLevels.Add(new UndoLevel());
            //Console.WriteLine("undo levels" + undoLevels.Count);
            //Console.WriteLine("commands " + this.Count());
        }
        public void PopUndoLevel() {
            if (undoLevels.Count == 0) {
                Console.WriteLine("no more undo levels");
                return;
            }
            undoLevels.RemoveAt(undoLevels.Count - 1);
        }


        public IEnumerator<Dictionary<string, object>> GetEnumerator() {
            foreach (UndoLevel l in undoLevels) { 
                foreach(Dictionary<string, object> d in l.commands){
                    yield return d;
                }
            }
        }
        public void Clear() {
            undoLevels.Clear();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}
