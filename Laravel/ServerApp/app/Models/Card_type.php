<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Card_type extends Model
{
    use HasFactory;
    use SoftDeletes;
    protected $guarded = false;

}
