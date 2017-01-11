using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
using static Xbim.Ifc2x3.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.StructuralElementsDomain
{
	public partial class IfcReinforcingBar : IExpressValidatable
	{
		public enum IfcReinforcingBarClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcReinforcingBarClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcReinforcingBarClause.WR1:
						retVal = (BarRole != IfcReinforcingBarRoleEnum.USERDEFINED) || ((BarRole == IfcReinforcingBarRoleEnum.USERDEFINED) && EXISTS(this/* as IfcObject*/.ObjectType));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc2x3.StructuralElementsDomain.IfcReinforcingBar");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcReinforcingBar.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcReinforcingBarClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcReinforcingBar.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}