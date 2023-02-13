<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Bank_account extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;


    public function valute()
    {
        return $this->hasOne(valute::class);
    }

    public function client()
    {
        return $this->hasMany(client::class);
    }
}
