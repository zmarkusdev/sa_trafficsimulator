using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataBridge.Communication;

namespace DataBridge.Services
{
    class RuleService : IRuleRepository
    {
        public Rule Create(Rule rule)
        {
            return DataAccessClient.Instance.Channel.CreateRule(rule);
        }

        public void Delete(Rule rule)
        {
            DataAccessClient.Instance.Channel.DeleteRule(rule);
        }

        public IEnumerable<Rule> GetAllRules()
        {
            return DataAccessClient.Instance.Channel.GetAllRules();
        }

        public IEnumerable<Rule> GetDynamicRules()
        {
            return DataAccessClient.Instance.Channel.GetDynamicRules();
        }

        public Rule GetRule(int ruleId)
        {
            return DataAccessClient.Instance.Channel.GetRule(ruleId);
        }

        public IEnumerable<Rule> GetStaticRules()
        {
            return DataAccessClient.Instance.Channel.GetStaticRules();
        }

        public Rule Update(Rule rule)
        {
            return DataAccessClient.Instance.Channel.UpdateRule(rule);
        }
    }
}
