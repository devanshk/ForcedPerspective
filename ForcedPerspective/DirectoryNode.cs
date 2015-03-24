using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForcedPerspective {
    class DirectoryNode {

        public List<DirectoryNode> subDirectories;
        public List<FileInfo> files;

        public string path;
        public long size = 0;
        public bool hasSubDirectories = false;
        public bool hasFiles = false;
        public int currentDepth, maxDepth;

        public DirectoryNode(String path, int depth, int maxdepth) {
            this.path = path;
            currentDepth = depth;
            maxDepth = maxdepth;
            Console.WriteLine(path);
            subDirectories = new List<DirectoryNode>();
            files = new List<FileInfo>();
            string[] sub = Directory.GetDirectories(this.path);
            if (currentDepth + 1 < maxDepth) {
                if (sub.Length > 0) {
                    hasSubDirectories = true;
                    DirectoryNode d;
                    for (int i = 0; i < sub.Length; i++) {
                        try {
                            d = new DirectoryNode(sub[i], currentDepth + 1, maxdepth);
                            size += d.size;
                            subDirectories.Add(d);
                        }
                        catch { }
                    }
                }
            }
            else {
                for (int i = 0; i < sub.Length; i++) {
                    //try {
                    size += getDirectorySize(sub[i]);
                    //} catch { }
                }
            }
            string[] containedFiles = Directory.GetFiles(this.path);
            if (containedFiles.Length > 0) {
                hasFiles = true;
                FileInfo f;
                for (int i = 0; i < containedFiles.Length; i++) {
                    try {
                        f = new FileInfo(containedFiles[i]);
                        size += f.Length;
                        files.Add(f);
                    }
                    catch (Exception e) { }
                }
            }
        }

        public long getBytes() {
            return size;
        }

        public float getKiloBytes() {
            return (size / 1024.0f);
        }

        public float getMegaBytes() {
            return (size / 1024.0f / 1024.0f);
        }

        public float getGigaBytes() {
            return (size / 1024.0f / 1024.0f / 1024.0f);
        }

        private long getDirectorySize(String location) {
            DirectoryInfo di = new DirectoryInfo(location);
            //IEnumerable<FileInfo> ugh = di.EnumerateFiles("*.*", SearchOption.AllDirectories);//.Sum(fi => fi.Length);
            FileInfo[] s = di.GetFiles("*.*", SearchOption.AllDirectories);
            return 10;
        }

    }
}
