using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//use array representation instead of list to improve look up time
//in sacrafice of space
public class TrieArray
{
    //root of the Trie
    private TrieArrayNode root;

    //constructor
    public TrieArray()
    {
        root = new TrieArrayNode();
    }

    //Insert a word into the Trie. O(m) time/space complexity. m is word length
    public void Insert(String word)
    {
        TrieArrayNode node = root;
        for (int i = 0; i < word.Length; ++i)
        {
            if (!node.ContainsKey(word[i]))
            {
                node.Put(word[i], new TrieArrayNode());
            }
            node = node.Get(word[i]);
        }
        node.SetEnd();
    }

    //search a prefix(or whole key) in trie and
    //returns the node where search ends
    //O(m) time complexity, O(1) space complexity
    private TrieArrayNode SearchPrefix(string prefix)
    {
        TrieArrayNode node = root;
        for (int i = 0; i < prefix.Length; ++i)
        {
            if (node.ContainsKey(prefix[i]))
            {
                node = node.Get(prefix[i]);
            } else
            {
                return null;
            }
        }
        return node;
    }

    //Search a whole word in the trie
    //Returns if the word is in the trie.
    public bool Search(String word)
    {
        TrieArrayNode node = SearchPrefix(word);
        return node != null && node.IsEnd();
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    // O(m) time complexity, O(1) space complexity
    public bool StartsWith(string prefix)
    {
        TrieArrayNode node = SearchPrefix(prefix);
        return node != null;
    }
}

public class TrieArrayNode
{
    //links to children node
    private TrieArrayNode[] children;
    //denote if this node is an word end
    private bool isEnd;
    //number of alphebet
    private const int A = 27;

    //constructor
    public TrieArrayNode()
    {
        children = new TrieArrayNode[A];
    }


    //check if a child exists
    public bool ContainsKey(char ch)
    {
        return children[ch-'a']!=null;
    }

    //get child
    public TrieArrayNode Get(char ch)
    {
        return children[ch-'a'];
    }

    //put a child node in
    public void Put(char ch, TrieArrayNode node)
    {
        children[ch-'a'] = node;
    }

    //set current node as word end
    public void SetEnd()
    {
        isEnd = true;
    }

    //check if current node is word end
    public bool IsEnd()
    {
        return isEnd;
    }
}

