using DataAccessLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge
{
    /// <summary>
    /// Implementation of the IRuleRepository.
    /// </summary>
    class BetterMockedRuleService : IRuleRepository
    {
        IRuleDataAccess ruleDataAccess = RuleDataAccessFactory.CreateRepository();
        IRuleDataAccess dynamicruleDataAccess = RuleDataAccessFactory.CreateRepository();

        public BetterMockedRuleService()
        {
            ruleDataAccess.LoadfromFile("rule");
        }

        public Rule Create(Rule rule)
        {
            return ruleDataAccess.Create(rule);
        }

        public void Delete(Rule rule)
        {
            ruleDataAccess.Delete(rule);
        }

        public IEnumerable<Rule> GetAllRules()
        {
            return ruleDataAccess.ReadAll();
        }

        public IEnumerable<Rule> GetDynamicRules()
        {
            return dynamicruleDataAccess.ReadAll();
        }

        public Rule GetRule(int ruleId)
        {
            return ruleDataAccess.ReadbyId(ruleId);
        }

        public IEnumerable<Rule> GetStaticRules()
        {
            return ruleDataAccess.ReadAll();
        }

        public Rule Update(Rule rule)
        {
            ruleDataAccess.Update(rule);
            return rule;
        }
    }
}
