using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [System.Serializable] 
    public class PanelInfo
    {
        public string panelName;//面板名称
        public GameObject panelObject;//面板对象
        public bool startHidden = true;//是否隐藏
        public int priority = 0;//优先级
    }
    [Header("UI Settings")]
    [SerializeField] private Transform uiParent;
    [SerializeField]
    private List<PanelInfo> panelInfos = new List<PanelInfo>();
    [Header("Events")]
    public UnityEvent<string> onPanelOpened = new UnityEvent<string>();//面板显示事件
    public UnityEvent<string> onPanelClosed = new UnityEvent<string>();//面板隐藏事件

    private Dictionary<string, GameObject> uiPannels = new Dictionary<string, GameObject>();//面板对象集合
    private Stack<string> panelHistory = new Stack<string>();//面板显示历史
    private HashSet<string> openPanels = new HashSet<string>();//当前显示的面板

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        InitilizePanels();
    }
    private void InitilizePanels()
    {
        foreach (var info in panelInfos)
        {
            uiPannels[info.panelName] = info.panelObject;
            if (info.startHidden)
            {
                info.panelObject.SetActive(false);
            }
            else
            {
                info.panelObject.SetActive(true);
                openPanels.Add(info.panelName);
            }

        }
    }
    public void ShowPanel(string panelName)
    {
        if (!uiPannels.ContainsKey(panelName)) return;
        if (openPanels.Contains(panelName)) return;
        CheckPanelPriorities(panelName);
        uiPannels[panelName].SetActive(true);
        openPanels.Add(panelName);
        panelHistory.Push(panelName);
        onPanelOpened.Invoke(panelName);
    }
    public void ClosePanel(string panelName)
    {
        if (!uiPannels.ContainsKey(panelName)) return;
        if (!openPanels.Contains(panelName)) return;
        uiPannels[panelName].SetActive(false);
        openPanels.Remove(panelName);
        onPanelClosed.Invoke(panelName);
    }
    void TogglePanel(string panelName)
    {
        if (openPanels.Contains(panelName))
        {
            ClosePanel(panelName);
        }
        else
        {
            ShowPanel(panelName);
        }
    }
    public void CloseAllPanels()
    {
        foreach (var panelName in openPanels)
        {
            ClosePanel(panelName);
        }
        openPanels.Clear();
        panelHistory.Clear();
    }
    public void Back()
    {
        if (panelHistory.Count == 0) return;
        string lastPanel = panelHistory.Pop();
        ClosePanel(lastPanel);
        if (panelHistory.Count > 0)
        {
            string previousPanel = panelHistory.Peek();
            ShowPanel(previousPanel);
        }
    }
    private void CheckPanelPriorities(string panelName)
    {
        int newPriority = GetPanelPriority(panelName);
        foreach (var panel in openPanels)
        {
            if (GetPanelPriority(panel) < newPriority)
            {
                ClosePanel(panel);
            }
            return;
        }
    }
    private int GetPanelPriority(string panelName)
    {
        foreach (var info in panelInfos)
        {
            if (info.panelName == panelName)
            {
                return info.priority;
            }
        }
        return 0;
    }
    public bool IsPanelOpen(string panelName)
    {
        return openPanels.Contains(panelName);
    }
}


