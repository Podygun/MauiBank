<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class AddCardprefixToCardTypesTable extends Migration
{

    public function up()
    {
        Schema::table('card_types', function (Blueprint $table) {
            $table->string('prefix')->nullable()->after('name');
        });
    }

    public function down()
    {
        Schema::table('card_types', function (Blueprint $table) {
            $table->dropColumn('prefix');
        });
    }
}
