using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;
using static AdventOfCode.Shared.Helpers.TreeBuilder;

namespace AdventOfCode2022
{
    public class SolveDay07 : ISolve
    {
        public string[] Input { get; set; }

        private readonly Stack<string> _folders = new Stack<string>();
        private Folder _currentFolder = new Folder();
        private readonly Folder _root;

        public SolveDay07()
        {
            Input = File.ReadAllLines("Inputs/Day07.txt");
            _root = _currentFolder;
        }

        public void SolvePartOne()
        {
            foreach (var line in Input)
            {
                if (line.StartsWith("$ cd"))
                {
                    var folder = line.Split(" ")[2];
                    if (folder == "..")
                        _currentFolder = _currentFolder.Parent;
                    else
                    {
                        var childFolder = new Folder(folder, _currentFolder);
                        _currentFolder.Childs.Add(childFolder);
                        _currentFolder = childFolder;
                    }
                }
                else
                {
                    var commands = line.Split(" ");
                    if (int.TryParse(commands[0], out var size))
                        _currentFolder.Size += size;
                }
            }

            int sum = 0;
            var st = new Stack<Folder>();
            var comp = new Stack<Folder>();
            st.Push(_root.Childs[0]);

            while (st.Count > 0)
            {
                _currentFolder = st.Pop();
                comp.Push(_currentFolder);

                foreach (var c in _currentFolder.Childs)
                {
                    st.Push(c);
                }
            }

            while (comp.Count > 0)
            {
                _currentFolder = comp.Pop();

                foreach (var c in _currentFolder.Childs)
                {
                    _currentFolder.Size += c.Size;
                }

                if (_currentFolder.Size <= 100000)
                    sum += _currentFolder.Size;
            }

            Console.WriteLine(sum);
        }

        public void SolvePartTwo()
        {
            var st = new Stack<Folder>();

            var targetsize = 30000000;
            var freesize = 70000000 - _root.Childs[0].Size;
            var chosen = _root.Childs[0].Size;
            st.Push(_root.Childs[0]);

            while (st.Count > 0)
            {
                _currentFolder = st.Pop();

                if (freesize + _currentFolder.Size >= targetsize)
                    chosen = Math.Min(chosen, _currentFolder.Size);

                foreach (var c in _currentFolder.Childs)
                {
                    st.Push(c);
                }
            }
            Console.WriteLine(chosen);
        }
    }

    public class Folder
    {
        public Folder()
        {
        }

        public Folder(string name, Folder parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; set; }
        public Folder Parent { get; set; }
        public List<Folder> Childs { get; set; } = new List<Folder>();
        public int Size { get; set; }
    }
}
