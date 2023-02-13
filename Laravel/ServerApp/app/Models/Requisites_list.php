<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Requisites_list extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;


    public function requisite()
    {
        return $this->hasMany(requisite::class);
    }

    public function organisation()
    {
        return $this->hasMany(organisation::class);
    }

}
