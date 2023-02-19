<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Favour extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;


    public function sub_favour()
    {
        return $this->hasOne(Favour::class);
    }

}
