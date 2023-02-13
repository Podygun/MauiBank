<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateCardsTable extends Migration
{

    public function up()
    {
        Schema::create('cards', function (Blueprint $table) {
            $table->id();
            $table->timestamps();
            $table->string('number', 31);
            $table->string('cvv', 4);
            $table->date('date_end');

            $table->unsignedBigInteger('card_type_id')->nullable();
            $table->unsignedBigInteger('bank_account_id')->nullable();

            $table->index('card_type_id', 'card_card_type_idx');
            $table->index('bank_account_id', 'card_bank_account_idx');

            $table->foreign('card_type_id', 'card_card_type_fk')
                ->on('card_types')->references('id');

            $table->foreign('bank_account_id', 'card_bank_account_fk')
                ->on('bank_accounts')->references('id');

            $table->softDeletes();
        });
    }


    public function down()
    {
        Schema::dropIfExists('cards');
    }
}
