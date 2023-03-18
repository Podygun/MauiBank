SELECT 
f.id
, f.name
, lists.id
, requisite_id
, req.name
, organisation_id
, org.name

FROM favours as f
join list_requisites as lists on f.list_requisites_id = lists.id
join requisites req on lists.requisite_id = req.id
join organisations org on lists.organisation_id = org.id

