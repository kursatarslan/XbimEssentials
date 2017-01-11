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
namespace Xbim.Ifc2x3.GeometricModelResource
{
	public partial class IfcBooleanResult : IExpressValidatable
	{
		public enum IfcBooleanResultClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcBooleanResultClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcBooleanResultClause.WR1:
						retVal = FirstOperand.Dim == SecondOperand.Dim;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc2x3.GeometricModelResource.IfcBooleanResult");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcBooleanResult.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcBooleanResultClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcBooleanResult.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}