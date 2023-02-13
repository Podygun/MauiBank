<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Favor extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;


    public function sub_favor()
    {
        return $this->hasOne(favor::class);
    }

}
