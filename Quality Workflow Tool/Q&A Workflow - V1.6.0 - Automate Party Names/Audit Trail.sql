
select
RequestID
,ProcessType
,ApprovalTeam
,UpdatedDate
,AssociateName
,PartyName
,PrincipalName
,QualityParameters
,'Pre' as Status
from (select *,ROW_NUMBER()over(partition by qualityparameters order by qualityparameters) as RowNum from tbl_approvals_daily_dotnet_trigger_update) a
where 1=1
--and convert(date,CompletionDate) between @StartDate and @EndDate
and requestid in (select distinct a.RequestID from vw_approvals_daily_dotnet a inner join tbl_approvals_daily_dotnet_trigger_update b on a.RequestID = b.RequestID and a.QualityParameters <> b.QualityParameters)
and a.RowNum = 1
union all
select
a.RequestID
,a.ProcessType
,a.ApprovalTeam
,a.LastUpdateDateTime
,a.AssociateName
,a.PartyName
,a.PrincipalName
,a.QualityParameters
,'Current' as Status
from tbl_approvals_daily_dotnet a 
where 1=1
and a.IsDeleted = 0
--and convert(date,CompletionDate) between @StartDate and @EndDate
and a.RequestID in 
		(select distinct a.RequestID 
			from tbl_approvals_daily_dotnet_trigger_update a inner join vw_approvals_daily_dotnet b on a.RequestID = b.RequestID where a.QualityParameters <> b.QualityParameters)
order by requestid,UpdatedDate






