<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Pay_check extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;

    const time = 'creation_date';


    public function account()
    {
        return $this->hasOne(account::class);
    }

    public function organization()
    {
        return $this->hasOne(account::class);
    }
}
