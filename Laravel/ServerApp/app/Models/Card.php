<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Card extends Model
{
    use HasFactory;
    use SoftDeletes;

    protected $guarded = [];
    public $custom;

    public function bank_account()
    {
        return $this->hasOne(bank_account::class, 'bank_account_id', 'id');
    }

    public function card_type()
    {
        return $this->hasOne(card_type::class, 'card_type_id', 'id');
    }


}
