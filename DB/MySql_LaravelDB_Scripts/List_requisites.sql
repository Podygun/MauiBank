SELECT 
list_requisites.id
, requisite_id
, req.name
, organisation_id
, org.name
, list_requisites.favour_id
, f.name

FROM laravel.list_requisites
join requisites req on requisite_id = req.id
join organisations org on organisation_id = org.id
join favours f on list_requisites.favour_id = f.id
order by req.name