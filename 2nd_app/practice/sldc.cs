using System;

namespace UltraEnterpriseSDLC
{
    enum RiskLevel
    {
        Low, Medium, High, Critical
    }

    enum SDLCStage
    {
        Backlog = 0, Requirement = 1, Design = 2, Development = 3, CodeReview = 4, Testing = 5, UAT = 6, Deployment = 7, Maintenance = 8
    }

    sealed class Requirement
    {
        public int Id{get;}
        public string? Title{get;}
        public RiskLevel risk{get;}

        public Requirement(int id, string title, RiskLevel risk)
        {
            this.Id = id;
            this.Title = title;
            this.risk = risk;
        }
    }

    sealed class WorkItem
    {
        public int Id{get;}
        public string? Name{get;}
        public SDLCStage stage{get; set;}
        public HashSet<int> DependencyId{get;}

        public WorkItem(int id, string name, SDLCStage stage){
            this.Id = id;
            this.Name = name;
            this.stage = stage;
            this.DependencyId = new HashSet<int>();
        }
    }

    sealed class BuildSnapshot
    {
        public string? Version{get;}
        public DateTime Timestamp{get;}

        public BuildSnapshot(string version)
        {
            this.Version = version;
            this.Timestamp = DateTime.Now;
        }
    }

    sealed class AuditLog
    {
        public DateTime Time{get;}
        public string? Action{get;}

        public AuditLog(string action)
        {
            this.Action = action;
            this.Time = DateTime.Now;
        }
    }

    sealed class QualityMetric
    {
        public string? Name{get;}
        public double Score{get;}

        public QualityMetric(string name, double score)
        {
            this.Name = name;
            this.Score = score;
        }
    }

    class EnterPriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releasedScoreboard;

        private int _requirementCounter, _workItemCounter;

        public EnterPriseSDLCEngine()
        {
            this._requirements = [];
            this._workItemRegistry = new Dictionary<int, WorkItem>();
            this._stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();
            
            foreach(var it in Enum.GetValues<SDLCStage>())
                _stageBoard[it] = new List<WorkItem>();
            
            this._executionQueue = new Queue<WorkItem>();
            this._rollbackStack = new Stack<BuildSnapshot>();
            this._uniqueTestSuites = new HashSet<string>();
            this._auditLedger = new LinkedList<AuditLog>();
            this._releasedScoreboard = new SortedList<double, QualityMetric>();
        }

        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement r = new Requirement(_requirementCounter, title, risk);
            _requirementCounter++;
            _requirements.Add(r);
            AuditLog audit = new AuditLog("Audit log from add-requirement");
            _auditLedger.Append(audit);
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem workItem = new WorkItem(_workItemCounter, name, stage);
            _workItemCounter++;
            _workItemRegistry[workItem.Id] = workItem;

            _stageBoard[stage].Add(workItem);                   // IMP

            AuditLog audit = new AuditLog("Audit log from create-work");

            _auditLedger.AddLast(audit);
            return workItem;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if(_workItemRegistry.ContainsKey(workItemId) && _workItemRegistry.ContainsKey(dependsOnId))
            {
                _workItemRegistry[workItemId].DependencyId.Add(dependsOnId);     //IMP
                AuditLog audit = new AuditLog("Audit log from AddDependency");
                _auditLedger.AddLast(audit);
            }
        }

        public void PlanStage(SDLCStage stage)
        {
            
        }

        public void ExecuteNext()
        {
            if(_executionQueue.Count == 0)
                return;
            
            var item = _executionQueue.Dequeue();
            var previous = item.stage;
            
            item.stage = item.stage + 1;
            _stageBoard[previous].Remove(item);
            _stageBoard[item.stage].Add(item);

            AuditLog audit = new AuditLog("Audit log from Execute-Next");
            _auditLedger.AddLast(audit);
        }

        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            AuditLog audit = new AuditLog("Audit log from RegisterTestSuite");
            _auditLedger.AddLast(audit);
        }

        public void DeployRelease(string version)
        {
            BuildSnapshot build = new BuildSnapshot(version);
            _rollbackStack.Push(build);
            
            AuditLog audit = new AuditLog("Audit log from DeployRelease");
            _auditLedger.AddLast(audit);
        }

        public void RollbackRelease()
        {
            if(_rollbackStack.Count == 0)
                return;
            _rollbackStack.Pop();
            
            AuditLog audit = new AuditLog("Audit log from RollbackRelease");
            _auditLedger.AddLast(audit);
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (!_releasedScoreboard.ContainsKey(score))
            {
                QualityMetric quality = new QualityMetric(metricName, score);
                _releasedScoreboard.Add(score, quality);
            }
        }

        public void PrintAuditLedger()
        {
            foreach(var it in _auditLedger)
                Console.WriteLine(it + " ");
        }
    }

}
